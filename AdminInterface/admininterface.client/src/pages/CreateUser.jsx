import React, { useState } from 'react';

function CreateUser() {
    const [nom, setNom] = useState('');
    const [prenom, setPrenom] = useState('');
    const [email, setEmail] = useState('');
    const [type, setType] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        console.log("nom:", nom);
        console.log("prenom:", prenom);
        console.log("email:", email);
        console.log("type:", type);

        if (!nom || !prenom || !email || !type) {
            setError("Tout les champs sont obligatoires.");
            return;
        }

        const utilisateur = {
            nom: nom,
            prenom: prenom,
            email: email,
            type: type,
            Mot_de_pass: "123",
        };

        try {
            const res = await fetch('/api/utilisateur', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(utilisateur)
            });

            if (!res.ok) {
                throw new Error('Erreur lors de la création');
            }

            setNom('');
            setPrenom('');
            setEmail('');
            setType('Client');
            alert("Utilisateur créé avec succès !");
            <Navigate to='/utilisateurs' />;
        } catch {
            setError("Erreur lors de la création de l'utilisateur.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Créer un utilisateur</h2>
                {error && <div className="alert alert-danger">{error}</div>}
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="userName">Nom</label>
                        <input type="text" className="form-control" id="userName" value={nom} onChange={(e) => setNom(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="userFirstName">Prénom</label>
                        <input type="text" className="form-control" id="userFirstName" value={prenom} onChange={(e) => setPrenom(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="userEmail">Email</label>
                        <input type="text" className="form-control" id="userEmail" value={email} onChange={(e) => setEmail(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="userType">Type</label>
                        <select className="form-control" id="userType" value={type} onChange={(e) => setType(e.target.value)} required >
                            <option value="">-- Sélectionnez le type --</option>
                            <option value="Client">Client</option>
                            <option value="Admin">Administrateur</option>
                        </select>
                    </div>

                    <div className="text-center mt-4">
                        <button type="submit" className="btn btn-danger">Créer l'utilisateur</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default CreateUser;