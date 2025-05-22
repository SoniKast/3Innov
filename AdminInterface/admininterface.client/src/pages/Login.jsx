import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [rememberMe, setRememberMe] = useState(false);
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch("/api/auth/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ Email: email, MotDePasse: password })
            });

            const data = await response.json();
            console.log("Réponse du serveur:", data);

            if (!response.ok) {
                setError(data.message || "Email ou mot de passe invalide");
                return;
            }

            // Vérifier le type du compte
            if (data.typeUtilisateur === "Client") {
                setError("Vous avez le mauvais type de compte.");
                return;
            }

            if (rememberMe) {
                localStorage.setItem("token", data.token); // persiste même après fermeture du navigateur
            } else {
                sessionStorage.setItem("token", data.token); // disparaît après fermeture
            }
            navigate("/");
            window.location.reload(); // Rafraichir la page d'accueil pour afficher le texte en haut
        } catch (error) {
            console.error("Erreur lors de la connexion:", error);
            setError("Erreur : " + error);
        }
    };

    return (
        <div className="container-fluid min-vh-80 d-flex justify-content-center align-items-center" style={{ flexGrow: 1 }}>
            <div className="p-4 main-page w-100" style={{ maxWidth: "500px" }}>
                <h1 className="text-center mb-4">Connexion</h1>
                <form onSubmit={handleLogin}>
                    <div className="form-group mt-3">
                        <label for="emailAddress">Adresse mail</label>
                        <input type="email" className="form-control" id="emailAddress" placeholder="Entrer son email" onChange={(e) => setEmail(e.target.value)} required></input>
                    </div>
                    <div className="form-group mt-3">
                        <label for="idPassword">Mot de passe</label>
                        <input type="password" className="form-control" id="idPassword" placeholder="Mot de passe" onChange={(e) => setPassword(e.target.value)} required></input>
                    </div>
                    <div className="form-group form-check mt-3">
                        <input type="checkbox" className="form-check-input" id="remember" checked={rememberMe} onChange={(e) => setRememberMe(e.target.checked)}></input>
                        <label className="form-check-label" for="remember">Se souvenir de moi</label>
                        <br></br>
                        <small class="text-muted">La session durera une heure si vous ne cochez pas cette case.</small>
                    </div>
                    {error && <p style={{ color: "red" }}>{error}</p>}
                    <div className="d-grid">
                        <button type="submit" className="btn btn-danger">Connexion</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Login;