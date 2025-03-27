import React, { useEffect, useState } from 'react';

function Tickets() {
    // State to store ticket data
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    // Fetch tickets from the API
    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const response = await fetch('https://localhost:7075/api/tickets');
                if (!response.ok) {
                    throw new Error('Failed to fetch tickets');
                }
                const data = await response.json();
                setTickets(data.$values); // The data will already be flattened
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
            <h1>Tickets</h1>
            <table className="table table-hover table-striped table-bordered border-dark">
                <thead className="table-dark">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Titre</th>
                        <th scope="col">Description</th>
                        <th scope="col">Statut</th>
                        <th scope="col">Utilisateur</th>
                    </tr>
                </thead>
                <tbody className="table-group-divider">
                    {tickets.length > 0 ? (
                        tickets.map((ticket, index) => (
                            <tr key={ticket.iD_Ticket}>
                                <td>{ticket.iD_Ticket}</td>
                                <td>{ticket.nom_Ticket}</td>
                                <td>{ticket.description_Ticket}</td>
                                <td>{ticket.etat_Ticket}</td>
                                <td>{ticket.utilisateurName}</td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="5" className="text-center">
                                No tickets found
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}

export default Tickets;
