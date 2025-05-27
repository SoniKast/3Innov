import { React, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
function Incidents() {
    // State to store ticket data
    const [incidents, setIncidents] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    // Fetch tickets from the API
    useEffect(() => {
        const fetchEquipement = async () => {
            try {
                const response = await fetch('/api/incidents/');
                if (!response.ok) {
                    throw new Error('Failed to fetch incidents');
                }
                const data = await response.json();
                setIncidents(data.$values); // The data will already be flattened
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
        return <div className="main-page"><center>Chargement des incidents...</center></div>;
    }

    if (error) {
        return <div className="main-page"><center>Erreur: {error}</center></div>;
    }

    return (
        <div className="main-page">
            <h1>Incidents</h1>
            <table className="table table-hover table-striped table-bordered border-dark">
                <thead className="table-dark">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">ID de l'équipement associé</th>
                        <th scope="col">Type de l'équipement associé</th>
                        <th scope="col">Rapport d'incident</th>
                        <th scope="col">Intervention</th>
                    </tr>
                </thead>
                <tbody className="table-group-divider">
                    {incidents.length > 0 ? (
                        incidents.map((incident) => (
                            <tr key={incident.iD_Incident}>
                                <td>{incident.iD_Incident}</td>
                                <td>{incident.iD_Equipement}</td>
                                <td>{incident.equipementType}</td>
                                <td>{incident.rapport_Incident}</td>
                                <td>
                                    <div className="text-center">
                                        <button className="btn btn-danger" onClick={() => navigate(`/incidents/${incident.iD_Incident}/edit`)}>
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
            <center><button className="btn btn-danger" onClick={() => navigate(`/register-incident/`)}>Enregistrer un incident</button></center>
        </div>
    );
}

export default Incidents;