import React, { useEffect, useState } from 'react';
import StatCard from '../components/StatCard';

const Home = () => {
    const [equipements, setEquipements] = useState([]);
    const [tickets, setTickets] = useState([]);
    const [incidents, setIncidents] = useState([]);
    const [utilisateurs, setUtilisateurs] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const [equipRes, ticketRes, incidentRes, userRes] = await Promise.all([
                    fetch('/api/equipements/'),
                    fetch('/api/tickets/'),
                    fetch('/api/incidents'),
                    fetch('/api/utilisateur/')
                ]);

                const equipData = await equipRes.json();
                const ticketData = await ticketRes.json();
                const incidentData = await incidentRes.json();
                const userData = await userRes.json();

                setEquipements(equipData.$values || equipData);
                setTickets(ticketData.$values || ticketData);
                setIncidents(incidentData.$values || incidentData);
                setUtilisateurs(userData.$values || userData);

            } catch (err) {
                console.error('Impossible de charger la base de données.', err);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    const activeTickets = tickets.filter(ticket => ticket.etat_Ticket !== 'Fermé');
    const ongoingTickets = tickets.filter(ticket => ticket.etat_Ticket === 'En cours');    
    const closedTickets = tickets.filter(ticket => ticket.etat_Ticket === 'Fermé');

    if (loading) return <div className="main-page"><center>Chargement des données...</center></div>;

    return (
        <div className="main-page container mt-4">
            <h1 className="mb-4">Accueil</h1>
            <div className="row g-4">
                <StatCard value={equipements.length} label="Équipements enregistrés" color="primary" linkTo="/monitoring"/>
                <StatCard value={activeTickets.length} label="Tickets actifs" color="warning" linkTo="/tickets" />
                <StatCard value={ongoingTickets.length} label="Tickets en cours" color="info" linkTo="/tickets" />
                <StatCard value={closedTickets.length} label="Tickets clôturés" color="success" linkTo="/tickets" />
                <StatCard value={incidents.length} label="Nombre d'incidents" color="danger" linkTo="/incidents" />
                <StatCard value={utilisateurs.length} label="Utilisateurs enregistrés" color="dark" linkTo="/utilisateurs" />
            </div>
        </div>
    );
};

export default Home;
