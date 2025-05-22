import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

function CreateTicket() {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [type, setType] = useState('bug');
    const [utilisateurId, setUtilisateurId] = useState('');
    const [incidentId, setIncidentId] = useState('');
    const [error, setError] = useState('');

    const [utilisateurs, setUtilisateurs] = useState([]);
    const [incidents, setIncidents] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const resUsers = await fetch('/api/utilisateur');
                const usersData = await resUsers.json();
                setUtilisateurs(usersData.$values);
            } catch {
                setError("Erreur lors du chargement des utilisateurs.");
            }

            try {
                const resIncidents = await fetch('/api/incidents');
                const incidentsData = await resIncidents.json();
                setIncidents(incidentsData.$values);
            } catch {
                setError("Erreur lors du chargement des incidents.");
            }
        };

        fetchData();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        console.log("title:", title);
        console.log("description:", description);
        console.log("utilisateurId:", utilisateurId);
        console.log("incidentId:", incidentId);

        if (!title || !description || !utilisateurId || !incidentId) {
            setError("Le titre, la description, l'utilisateur et l'incident sont obligatoires.");
            return;
        }

        const ticket = {
            nom_Ticket: title,
            description_Ticket: description,
            etat_Ticket: "Ouvert",
            type_de_tickets: type,
            id_Utilisateur: parseInt(utilisateurId),
            id_Incident: parseInt(incidentId),
        };

        try {
            const res = await fetch('/api/tickets', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(ticket)
            });

            if (!res.ok) {
                throw new Error('Erreur lors de la création');
            }

            setTitle('');
            setDescription('');
            setType('bug');
            setUtilisateurId('');
            setIncidentId('');
            setError('');
            alert("Ticket créé avec succès !");
            <Navigate to='/tickets' />;
        } catch {
            setError("Erreur lors de la création du ticket.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Créer un Ticket</h2>
                {error && <div className="alert alert-danger">{error}</div>}
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="ticketTitle">Titre du Ticket</label>
                        <input type="text" className="form-control" id="ticketTitle" value={title} onChange={(e) => setTitle(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="ticketDescription">Description</label>
                        <textarea className="form-control" id="ticketDescription" rows="4" value={description} onChange={(e) => setDescription(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="ticketType">Type</label>
                        <select className="form-control" id="ticketType" value={type} onChange={(e) => setType(e.target.value)}>
                            <option value="bug">Bug</option>
                            <option value="maintenance">Maintenance</option>
                            <option value="amelioration">Amélioration</option>
                        </select>
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="utilisateurSelect">Utilisateur</label>
                        <select className="form-control" id="utilisateurSelect" value={utilisateurId} onChange={(e) => setUtilisateurId(e.target.value)} required>
                            <option value="">-- Sélectionnez un utilisateur --</option>
                            {utilisateurs.map(utilisateur => (
                                <option key={utilisateur.iD_Utilisateur} value={utilisateur.iD_Utilisateur}>
                                    {utilisateur.prenom} {utilisateur.nom}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="incidentSelect">Incident</label>
                        <select className="form-control" id="incidentSelect" value={incidentId} onChange={(e) => setIncidentId(e.target.value)} required>
                            <option value="">-- Sélectionnez un incident --</option>
                            {incidents.map(incident => (
                                <option key={incident.iD_Incident} value={incident.iD_Incident}>
                                    {incident.rapport_Incident}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="text-center mt-4">
                        <button type="submit" className="btn btn-primary">Créer le Ticket</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default CreateTicket;
