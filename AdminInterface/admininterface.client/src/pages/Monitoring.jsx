import { React, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
function Monitoring() {
    // State to store ticket data
    const [equipement, setEquipement] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    // Fetch tickets from the API
    useEffect(() => {
        const fetchEquipement = async () => {
            try {
                const response = await fetch('/api/equipements/');
                if (!response.ok) {
                    throw new Error('Failed to fetch equipement');
                }
                const data = await response.json();
                setEquipement(data.$values); // The data will already be flattened
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchEquipement();
    }, []);

    // Render loading state or error message
    if (loading) {
        return <div className="main-page"><center>Chargement de l'équipement...</center></div>;
    }

    if (error) {
        return <div className="main-page"><center>Error: {error}</center></div>;
    }

    return (
        <div className="main-page">
            <h1>Equipement</h1>
            <table className="table table-hover table-striped table-bordered border-dark">
                <thead className="table-dark">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Type</th>
                        <th scope="col">Description</th>
                        <th scope="col">Marque</th>
                        <th scope="col">Modèle</th>
                        <th scope="col">Commentaire</th>
                        <th scope="col">Adresse IP</th>
                        <th scope="col">Groupe Associé</th>
                        <th scope="col">Intervention</th>
                    </tr>
                </thead>
                <tbody className="table-group-divider">
                    {equipement.length > 0 ? (
                        equipement.map((equipement, index) => (
                            <tr key={equipement.iD_Equipement}>
                                <td>{equipement.iD_Equipement}</td>
                                <td>{equipement.type_equipement}</td>
                                <td>{equipement.description_equipement}</td>
                                <td>{equipement.marque}</td>
                                <td>{equipement.modele}</td>
                                <td>{equipement.commentaire}</td>
                                <td>{equipement.adresse_IP}</td>
                                <td>{equipement.groupe.nom_GroupeM}</td>
                                <td>
                                    <div className="text-center">
                                        <button className="btn btn-danger" onClick={() => navigate(`/monitoring/${equipement.iD_Equipement}/ping`, { state: { ip: equipement.adresse_IP } })}>
                                            Suivi
                                        </button>
                                        <br>
                                        </br>
                                        <br>
                                        </br>
                                        <button className="btn btn-danger" onClick={() => navigate(`/monitoring/${equipement.iD_Equipement}/edit`)}>
                                            Modification
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="5" className="text-center">
                                Aucun équipement enregistré.
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
            <center><button className="btn btn-danger" onClick={() => navigate(`/register-equipment/`)}>Enregistrer un équipement</button></center>
        </div>
    );
}

export default Monitoring;