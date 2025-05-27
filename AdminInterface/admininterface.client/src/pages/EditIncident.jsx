import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

function EditIncident() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [equipementId, setEquipementId] = useState('');
    const [rapport, setRapport] = useState('');
    const [equipements, setEquipements] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchIncident = async () => {
            try {
                const res = await fetch(`/api/incidents/${id}`);
                if (!res.ok) throw new Error("Incident non trouvé");
                const data = await res.json();

                setEquipementId(data.iD_Equipement || data.ID_Equipement);
                setRapport(data.rapport_Incident || data.Rapport_Incident);
            } catch {
                setError("Erreur lors du chargement de l'incident.");
            }
        };

        const fetchEquipements = async () => {
            try {
                const res = await fetch('/api/equipements');
                const data = await res.json();
                setEquipements(data.$values || data);
            } catch {
                setError("Erreur lors du chargement des équipements.");
            }
        };

        fetchIncident();
        fetchEquipements();
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!equipementId || !rapport) {
            setError("L'ID et le rapport sont obligatoires.");
            return;
        }

        const updatedIncident = {
            ID_Incident: parseInt(id),
            ID_Equipement: parseInt(equipementId),
            Rapport_Incident: rapport,
        };

        try {
            const res = await fetch(`/api/incidents/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(updatedIncident)
            });

            if (!res.ok) throw new Error("Erreur lors de la mise à jour");

            navigate('/incidents');
        } catch {
            setError("Erreur lors de la modification de l'incident.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Modifier les détails de l'incident</h2>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="EquipmentID">Équipement associé</label>
                        <select
                            className="form-control"
                            id="EquipmentID"
                            value={equipementId}
                            onChange={(e) => setEquipementId(e.target.value)}
                            required
                        >
                            <option value="">-- Sélectionnez un équipement --</option>
                            {equipements.map((equipement) => (
                                <option key={equipement.iD_Equipement} value={equipement.iD_Equipement}>
                                    Type: {equipement.type_equipement}, Modèle: {equipement.modele}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="RapportIncident">Rapport de l'incident</label>
                        <textarea
                            className="form-control"
                            id="RapportIncident"
                            rows="4"
                            value={rapport}
                            onChange={(e) => setRapport(e.target.value)}
                            required
                        />
                    </div>
                    {error && <div className="alert alert-danger">{error}</div>}
                    <div className="text-center mt-4">
                        <button type="submit" className="btn btn-success">
                            Mettre à jour l'incident
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default EditIncident;
