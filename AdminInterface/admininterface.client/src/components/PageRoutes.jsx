import Home from '../pages/Home';
import Monitoring from '../pages/Monitoring';
import Tickets from '../pages/Tickets';
import CreateTicket from '../pages/CreateTicket';
import CreateUser from '../pages/CreateUser';
import Utilisateurs from '../pages/Utilisateurs';
import Statistics from '../pages/Statistics';
import Incidents from '../pages/Incidents';
import RegisterEquipment from '../pages/RegisterEquipment';

const PageRoutes = [
    { path: '/', name: 'Accueil', component: Home },
    { path: '/monitoring', name: 'Monitoring', component: Monitoring },
    { path: '/tickets', name: 'Tickets', component: Tickets },
    { path: '/create-ticket', name: 'Créer un Ticket', component: CreateTicket },
    { path: '/register-equipment', name: 'Enregistrer un Équipement', component: RegisterEquipment },
    { path: '/create-user', name: 'Créer un utilisateur', component: CreateUser },
    { path: '/utilisateurs', name: 'Utilisateurs', component: Utilisateurs },
    { path: '/incidents', name: 'Incidents', component: Incidents },
    { path: '/stats', name: 'Statistiques', component: Statistics },
];

export default PageRoutes;