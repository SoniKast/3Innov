import Home from '../pages/Home';
import Monitoring from '../pages/Monitoring';
import Tickets from '../pages/Tickets';
import Ping from './Ping';
import CreateTicket from '../pages/CreateTicket';
import Utilisateurs from '../pages/Utilisateurs';
import Statistics from '../pages/Statistics';
import RegisterEquipment from '../pages/RegisterEquipment';

const PageRoutes = [
    { path: '/', name: 'Accueil', component: Home },
    { path: '/monitoring', name: 'Monitoring', component: Monitoring },
    { path: '/tickets', name: 'Tickets', component: Tickets },
    { path: '/create-ticket', name: 'Créer un Ticket', component: CreateTicket },
    { path: '/register-equipment', name: 'Enregistrer un Équipement', component: RegisterEquipment },
    { path: '/utilisateurs', name: 'Utilisateurs', component: Utilisateurs },
    { path: '/stats', name: 'Statistiques', component: Statistics },
];

export default PageRoutes;