import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

function EditEquipement() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [type, setType] = useState('');
    const [description, setDescription] = useState('');
    const [marque, setMarque] = useState('');
    const [modele, setModele] = useState('');
    const [commentaire, setCommentaire] = useState('');
    const [adresseIP, setAdresseIP] = useState('');
    const [groupeID, setGroupeID] = useState('');
    const [groupes, setGroupes] = useState([]);
    const [error, setError] = useState('');

    // Charger l’équipement existant
    useEffect(() => {
        const fetchEquipement = async () => {
            try {
                const res = await fetch(`/api/equipements/${id}`);
                if (!res.ok) throw new Error("Erreur lors du chargement de l'équipement.");
                const data = await res.json();

                setType(data.type_equipement);
                setDescription(data.description_equipement);
                setMarque(data.marque);
                setModele(data.modele);
                setCommentaire(data.commentaire);
                setAdresseIP(data.adresse_IP);
                setGroupeID(data.groupe?.iD_Groupe || '');
            } catch (err) {
                setError(err.message);
            }
        };

        const fetchGroupes = async () => {
            try {
                const res = await fetch('/api/groupes');
                const data = await res.json();
                setGroupes(data.$values);
            } catch {
                setError("Erreur lors du chargement des groupes.");
            }
        };

        fetchEquipement();
        fetchGroupes();
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        const updatedEquipement = {
            id_Equipement: parseInt(id),
            type_equipement: type,
            description_equipement: description,
            marque,
            modele,
            commentaire,
            adresse_IP: adresseIP,
            groupe: parseInt(groupeID),
        };

        try {
            const res = await fetch(`/api/equipements/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(updatedEquipement)
            });

            if (!res.ok) {
                throw new Error('Erreur lors de la mise à jour');
            }

            alert("Équipement modifié avec succès !");
            navigate('/monitoring');
        } catch {
            setError("Erreur lors de la modification de l'équipement.");
        }
    };

    return (
        <div className="main-page container mt-5">
            <h2 className="text-center mb-4">Modifier un équipement</h2>
            {error && <div className="alert alert-danger">{error}</div>}
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Type</label>
                    <input type="text" className="form-control" value={type} onChange={(e) => setType(e.target.value)} required />
                </div>
                <div className="form-group mt-3">
                    <label>Description</label>
                    <textarea rows="4" className="form-control" value={description} onChange={(e) => setDescription(e.target.value)} required />
                </div>
                <div className="form-group mt-3">
                    <label>Marque</label>
                    <input type="text" className="form-control" value={marque} onChange={(e) => setMarque(e.target.value)} required />
                </div>
                <div className="form-group mt-3">
                    <label>Modèle</label>
                    <input type="text" className="form-control" value={modele} onChange={(e) => setModele(e.target.value)} required />
                </div>
                <div className="form-group mt-3">
                    <label>Commentaire</label>
                    <input type="text" className="form-control" value={commentaire} onChange={(e) => setCommentaire(e.target.value)} required />
                </div>
                <div className="form-group mt-3">
                    <label>Adresse IP</label>
                    <input type="text" className="form-control" value={adresseIP} onChange={(e) => setAdresseIP(e.target.value)} required />
                </div>
                <div className="form-group mt-3">
                    <label>Groupe</label>
                    <select className="form-control" value={groupeID} onChange={(e) => setGroupeID(e.target.value)} required>
                        <option value="">-- Sélectionnez un groupe --</option>
                        {groupes.map((groupe) => (
                            <option key={groupe.iD_Groupe} value={groupe.iD_Groupe}>
                                {groupe.nom_GroupeM}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="text-center mt-4">
                    <button type="submit" className="btn btn-success">Enregistrer les modifications</button>
                </div>
            </form>
        </div>
    );
}

export default EditEquipement;
