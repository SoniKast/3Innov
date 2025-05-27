import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

function EditTicket() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [etat, setEtat] = useState('');
    const [type, setType] = useState('');
    const [utilisateurId, setUtilisateurId] = useState('');
    const [incidentId, setIncidentId] = useState('');
    const [error, setError] = useState('');

    const [utilisateurs, setUtilisateurs] = useState([]);
    const [incidents, setIncidents] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const resTicket = await fetch(`/api/tickets/${id}`);
                if (!resTicket.ok) throw new Error("Ticket non trouvé");
                const ticketData = await resTicket.json();

                setTitle(ticketData.nom_Ticket);
                setDescription(ticketData.description_Ticket);
                setEtat(ticketData.etat_Ticket);
                setType(ticketData.type_de_tickets);
                setUtilisateurId(ticketData.id_Utilisateur);
                setIncidentId(ticketData.id_Incident);
            } catch {
                setError("Erreur lors du chargement du ticket.");
            }

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
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!title || !description || !utilisateurId || !incidentId) {
            setError("Le titre, la description, l'utilisateur et l'incident sont obligatoires.");
            return;
        }

        const updatedTicket = {
            id_Ticket: parseInt(id),
            nom_Ticket: title,
            description_Ticket: description,
            etat_Ticket: etat,
            type_de_tickets: type,
            id_Utilisateur: parseInt(utilisateurId),
            id_Incident: parseInt(incidentId),
        };

        try {
            const res = await fetch(`/api/tickets/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(updatedTicket)
            });

            if (!res.ok) throw new Error("Erreur lors de la mise à jour");

            navigate('/tickets');
        } catch {
            setError("Erreur lors de la modification du ticket.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Modifier le Ticket</h2>
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
                        <label htmlFor="ticketEtat">État</label>
                        <select className="form-control" id="ticketEtat" value={etat} onChange={(e) => setEtat(e.target.value)}>
                            <option value="Ouvert">Ouvert</option>
                            <option value="En cours">En cours</option>
                            <option value="Fermé">Fermé</option>
                        </select>
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
                        <button type="submit" className="btn btn-success">Mettre à jour le Ticket</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default EditTicket;
