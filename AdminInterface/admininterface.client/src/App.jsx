import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home.jsx';
import Monitoring from './pages/Monitoring.jsx';
import Tickets from './pages/Tickets.jsx';
import Register from './pages/Register.jsx';
import Login from './pages/Login.jsx';
import Dashboard from './pages/Dashboard.jsx';

const App = () => {
    return (
        <div>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/monitoring" element={<Monitoring />} />
                <Route path="/tickets" element={<Tickets />} />
                <Route path="/dashboard" element={<Dashboard />} />
                <Route path="/register" element={<Register />} />
                <Route path="/login" element={<Login />} />
            </Routes>
        </div>
    );
};

export default App;