import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
function EditUser() {
    const { id } = useParams(); // récupère l'ID depuis l'URL
    const navigate = useNavigate();

    const [nom, setNom] = useState('');
    const [prenom, setPrenom] = useState('');
    const [email, setEmail] = useState('');
    const [type, setType] = useState('');
    const [motDePasse, setMotDePasse] = useState(''); 
    const [error, setError] = useState('');

    useEffect(() => {
        if (id) {
            fetch(`/api/utilisateur/${id}`)
                .then(res => {
                    if (!res.ok) throw new Error('Erreur lors du chargement de l\'utilisateur');
                    return res.json();
                })
                .then(data => {
                    setNom(data.nom);
                    setPrenom(data.prenom);
                    setEmail(data.email);
                    setMotDePasse(data.mot_de_pass);
                    setType(data.type);
                })
                .catch(() => setError("Impossible de charger les données de l'utilisateur."));
        }
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        console.log("nom:", nom);
        console.log("prenom:", prenom);
        console.log("email:", email);
        console.log("type:", type);
        console.log("mot_de_pass:", motDePasse);

        if (!nom || !prenom || !email || !type) {
            setError("Tout les champs sont obligatoires.");
            return;
        }

        const utilisateur = {
            nom, prenom, email, type, mot_de_pass: motDePasse,
        };

        try {
            const res = await fetch(`/api/utilisateur/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(utilisateur)
            });

            if (!res.ok) {
                throw new Error('Erreur lors de la modification');
            }

            alert("Utilisateur modifié avec succès !");
            <Navigate to='/utilisateurs' />;
        } catch {
            setError("Erreur lors de la modification de l'utilisateur.");
        }
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Modifier un utilisateur</h2>
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
                        <input type="email" className="form-control" id="userEmail" value={email} onChange={(e) => setEmail(e.target.value)} required />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="userPassword">Mot de passe</label>
                        <input type="password" className="form-control" id="userPassword" value={motDePasse} onChange={(e) => setMotDePasse(e.target.value)} required />
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
                        <button type="submit" className="btn btn-primary">Modifier l'utilisateur</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default EditUser;