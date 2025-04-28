import React, { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';

const Ping = () => {
    const [pingResult, setPingResult] = useState('');
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');
    const location = useLocation();
    const ipAddress = location.state?.ip;

    useEffect(() => {
        if (ipAddress) {
            fetchPingResult();
        }
    }, [ipAddress]);

    const fetchPingResult = async () => {
        if (!ipAddress) {
            setError('Aucune adresse IP fournie.');
            return;
        }

        setLoading(true);
        setError('');
        setPingResult('');

        try {
            const response = await fetch(`http://localhost:5000/api/ping?ip=${ipAddress}`);

            if (!response.ok) {
                throw new Error('Erreur lors de l\'exécution du ping.');
            }

            const data = await response.json();
            setPingResult(data.result);
        } catch (err) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="main-page">
            <h1>Suivi de l'équipement</h1>

            {loading && <div className="text-center">Chargement...</div>}
            {error && <div className="text-center text-danger">{error}</div>}

            {ipAddress && (
                <div>
                    <h3>Résultat du Ping pour l'IP : {ipAddress}</h3>
                    {pingResult ? (
                        <pre>{pingResult}</pre>
                    ) : (
                        <div className="text-center">Pas de résultat pour le moment.</div>
                    )}
                </div>
            )}
        </div>
    );
};

export default Ping;