﻿import { React, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
function Monitoring() {
    // State to store ticket data
    const [equipement, setEquipement] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    // Fetch tickets from the API
    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const response = await fetch('https://localhost:7075/api/equipements/');
                if (!response.ok) {
                    throw new Error('Failed to fetch tickets');
                }
                const data = await response.json();
                setEquipement(data.$values); // The data will already be flattened
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchTickets();
    }, []);

    // Render loading state or error message
    if (loading) {
        return <div className="main-page"><center>Chargement des tickets...</center></div>;
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
                                    <button className="btn btn-primary" onClick={() => navigate(`/monitoring/${equipement.iD_Equipement}`)}
                                    >
                                        Suivi
                                    </button>
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
        </div>
    );
}

export default Monitoring;