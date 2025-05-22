import React, { useEffect, useState } from 'react';

function RegisterEquipment() {
    const [type, setType] = useState('');
    const [marque, setMarque] = useState('');
    const [description, setDescription] = useState('');
    const [modele, setModele] = useState('');
    const [commentaire, setCommentaire] = useState('');
    const [adresseIP, setAdresseIP] = useState('');
    const [groupeID, setGroupeID] = useState('');
    const [groupes, setGroupes] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const resGroupe = await fetch('/api/groupes');
                const groupeData = await resGroupe.json();
                setGroupes(groupeData.$values);
            } catch {
                setError("Erreur lors du chargement des groupes.");
            }
        };

        fetchData();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!type || !marque || !description || !modele || !commentaire || !adresseIP || !groupeID) {
            setError("Tous les champs sont obligatoire.");
            return;
        }

        const equipement = {
            type_equipement: type,
            description_equipement: description,
            marque: marque,
            modele: modele,
            commentaire: commentaire,
            adresse_IP: adresseIP,
            groupe: parseInt(groupeID),
        };

        try {
            const res = await fetch('/api/equipements', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(equipement)
            });

            if (!res.ok) {
                throw new Error('Erreur lors de la création');
            }

            setType('');
            setMarque('');
            setDescription('');
            setModele('');
            setCommentaire('');
            setAdresseIP('');
            setGroupeID('');
            alert("Equipement créé avec succès !");
            <Navigate to='/monitoring' />;
        } catch {
            setError("Erreur lors de la création de l'utilisateur.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Enregistrer un équipement</h2>
                {error && <div className="alert alert-danger">{error}</div>}
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="equipementType">Type</label>
                        <input type="text" className="form-control" id="equipementType" value={type} onChange={(e) => setType(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="equipementDescription">Description</label>
                        <textarea rows="4" className="form-control" id="equipementDescription" value={description} onChange={(e) => setDescription(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="equipementMarque">Marque</label>
                        <input type="text" className="form-control" id="equipementMarque" value={marque} onChange={(e) => setMarque(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="equipementModele">Modele</label>
                        <input type="text" className="form-control" id="equipementModele" value={modele} onChange={(e) => setModele(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="equipementCommentaire">Commentaire</label>
                        <input type="text" className="form-control" id="equipementCommentaire" value={commentaire} onChange={(e) => setCommentaire(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="equipementAdresseIP">Adresse IP</label>
                        <input type="text" className="form-control" id="equipementAdresseIP" value={adresseIP} onChange={(e) => setAdresseIP(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="equipementGroupe">Groupe</label>
                        <select className="form-control" id="equipementGroupe" value={groupeID} onChange={(e) => setGroupeID(e.target.value)} required >
                            <option value="">-- Sélectionnez un groupe --</option>
                            {groupes.map(groupe_db => (
                                <option key={groupe_db.iD_Groupe} value={groupe_db.iD_Groupe}>
                                    {groupe_db.nom_GroupeM}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="text-center mt-4">
                        <button type="submit" className="btn btn-danger">Enregistrer</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default RegisterEquipment;