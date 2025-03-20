import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import Footer from './components/Footer';
import Home from './pages/Home';
import Monitoring from './pages/Monitoring';
import Tickets from './pages/Tickets';
import Register from './pages/Register';
import Login from './pages/Login';
import Dashboard from './pages/Dashboard';

const App = () => {
    return (
        <div className="app-container">
            <Header />
            <div className="d-flex">
                <Sidebar />
                <div className="content p-3">
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/monitoring" element={<Monitoring />} />
                        <Route path="/tickets" element={<Tickets />} />
                        <Route path="/dashboard" element={<Dashboard />} />
                        <Route path="/register" element={<Register />} />
                        <Route path="/login" element={<Login />} />
                    </Routes>
                </div>
            </div>
            <Footer />
        </div>
    );
};

export default App;