import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
function RegisterIncident() {
    const navigate = useNavigate();
    const [equipementId, setEquipementId] = useState('');
    const [rapport, setRapport] = useState('');
    const [equipements, setEquipements] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchEquipement = async () => {
            try {
                const res = await fetch('/api/equipements');
                const data = await res.json();
                setEquipements(data.$values);
            } catch {
                setError("Erreur lors du chargement des équipements.");
            }
        };

        fetchEquipement();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        console.log("ID Equipement:", equipementId);
        console.log("Rapport:", rapport);

        if (!equipementId || !rapport) {
            setError("L'ID et le rapport sont obligatoires.");
            return;
        }

        const incident = {
            ID_Equipement: parseInt(equipementId),
            Rapport_Incident: rapport
        };

        try {
            const res = await fetch('/api/incidents', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(incident)
            });

            if (!res.ok) {
                throw new Error('Erreur lors de la création');
            }

            setEquipementId('');
            setRapport('');
            alert("Incident enregistré avec succès !");
            navigate('/incidents');
        } catch {
            setError("Erreur lors de la création de l'incident.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Enregistrer un incident.</h2>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="EquipmentID">ID de l'équipement associé</label>
                        <select className="form-control" id="EquipmentID" value={equipementId} onChange={(e) => setEquipementId(e.target.value)} required>
                            <option value="">-- Sélectionnez un équipement --</option>
                            {equipements.map(equipement => (
                                <option key={equipement.iD_Equipement} value={equipement.iD_Equipement}>
                                    Type: {equipement.type_equipement}, Modèle: {equipement.modele}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="ticketDescription">Rapport de l'incident</label>
                        <textarea className="form-control" id="ticketDescription" rows="4" value={rapport} onChange={(e) => setRapport(e.target.value)} required />
                    </div>

                    {error && <div className="alert alert-danger">{error}</div>}

                    <div className="text-center mt-4">
                        <button type="submit" className="btn btn-danger">Enregistrer un incident</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default RegisterIncident;
