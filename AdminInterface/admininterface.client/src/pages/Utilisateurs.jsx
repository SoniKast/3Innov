import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Utilisateurs() {
    // State to store ticket data
    const [utilisateurs, setUtilisateurs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    // Fetch tickets from the API
    useEffect(() => {
        const fetchUtilisateurs = async () => {
            try {
                const response = await fetch('/api/utilisateur');
                if (!response.ok) {
                    throw new Error('Failed to fetch tickets');
                }
                const data = await response.json();
                setUtilisateurs(data.$values); // The data will already be flattened
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        fetchUtilisateurs();
    }, []);

    // Render loading state or error message
    if (loading) {
        return <div className="main-page"><center>Chargement des utilisateurs...</center></div>;
    }

    if (error) {
        return <div className="main-page"><center>Error: {error}</center></div>;
    }

    return (
        <div className="main-page">
            <h1>Utilisateurs</h1>
            <table className="table table-hover table-striped table-bordered border-dark">
                <thead className="table-dark">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Name</th>
                        <th scope="col">Email</th>
                        <th scope="col">Tickets</th>
                        <th scope="col">Type de compte</th>
                        <th scope="col">Modifications</th>
                    </tr>
                </thead>
                <tbody className="table-group-divider">
                    {utilisateurs.length > 0 ? (
                        utilisateurs.map((utilisateur, index) => (
                            <tr key={utilisateur.iD_Utilisateur}>
                                <th scope="row">{index + 1}</th>
                                <td>{`${utilisateur.nom} ${utilisateur.prenom}`}</td>
                                <td>{utilisateur.email}</td>
                                <td>
                                    {utilisateur.tickets.$values && utilisateur.tickets.$values.length > 0 ? (
                                        <ul>
                                            {utilisateur.tickets.$values.map(ticket => (
                                                <li key={ticket.iD_Ticket}>
                                                    {ticket.nom_Ticket} - {ticket.etat_Ticket}
                                                </li>
                                            ))}
                                        </ul>
                                    ) : (
                                        <p>Aucun tickets</p>
                                    )}
                                </td>
                                <td>{utilisateur.type}</td>
                                <td>
                                    <button className="btn btn-danger" onClick={() => navigate(`/utilisateurs/${utilisateur.iD_Utilisateur}/edit`, { state: { id: utilisateur.iD_Utilisateur } })}>
                                        Modifier
                                    </button>
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="4" className="text-center">
                                No tickets found
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
            <center><button className="btn btn-danger" onClick={() => navigate(`/create-user/`) }>Créer un utilisateur</button></center>
        </div>
    );
}

export default Utilisateurs;
