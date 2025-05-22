import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Tickets() {
    // State to store ticket data
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [filter, setFilter] = useState("Tous");
    const navigate = useNavigate();

    // Fetch tickets from the API
    useEffect(() => {
        const fetchTickets = async () => {
            try {
                const response = await fetch('/api/tickets');
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

    // Fonction pour filtrer les tickets
    const filteredTickets = tickets.filter(ticket =>
        filter === "Tous" || ticket.etat_Ticket === filter
    );

    // Render loading state or error message
    if (loading) {
        return <div className="main-page"><center>Chargement des tickets...</center></div>;
    }

    if (error) {
        return <div className="main-page"><center>Error: {error}</center></div>;
    }

    return (
        <div className="main-page">
            <h1 className="text-center">Tickets</h1>
            <div className="dropdown mb-3">
                 <button type="button" className="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown">
                    Trier par : {filter}
                 </button>
                 <ul className="dropdown-menu">
                     <li><button className="dropdown-item" onClick={() => setFilter("Tous")}>Tous</button></li>
                     <li><button className="dropdown-item" onClick={() => setFilter("Ouvert")}>Ouvert</button></li>
                     <li><button className="dropdown-item" onClick={() => setFilter("En cours")}>En cours</button></li>
                     <li><button className="dropdown-item" onClick={() => setFilter("Fermé")}>Fermé</button></li>
                 </ul>
            </div>

            <table className="table table-hover table-striped table-bordered border-dark">
                <thead className="table-dark">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Titre</th>
                        <th scope="col">Description</th>
                        <th scope="col">Statut</th>
                        <th scope="col">Utilisateur</th>
                        <th scope="col">Intervention</th>
                    </tr>
                </thead>
                <tbody className="table-group-divider">
                    {filteredTickets.length > 0 ? (
                        filteredTickets.map((ticket) => (
                            <tr key={ticket.iD_Ticket}>
                                <td>{ticket.iD_Ticket}</td>
                                <td>{ticket.nom_Ticket}</td>
                                <td>{ticket.description_Ticket}</td>
                                <td>{ticket.etat_Ticket}</td>
                                <td>{ticket.utilisateurName}</td>
                                <td>
                                    <button className="btn btn-danger" onClick={() => navigate(`/tickets/${ticket.iD_Ticket}/edit`)}>
                                        Modification
                                    </button>
                                </td>
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
