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
            setError("Une erreur est survenue, veuillez réessayer.");
        }
    };

    return (
        <div className="main-page">
            <h1 className="text-center">
                Connexion
            </h1>
            <form className="login-form col-5" onSubmit={handleLogin}>
                <div className="form-group">
                    <label for="emailAddress">Adresse mail</label>
                    <input type="email" className="form-control" id="emailAddress" placeholder="Entrer son email" onChange={(e) => setEmail(e.target.value)} required></input>
                </div>
                <div className="form-group">
                    <label for="idPassword">Mot de passe</label>
                    <input type="password" className="form-control" id="idPassword" placeholder="Mot de passe" onChange={(e) => setPassword(e.target.value)} required></input>
                </div>
                <div className="form-group form-check">
                    <input type="checkbox" className="form-check-input" id="remember" checked={rememberMe} onChange={(e) => setRememberMe(e.target.checked)}></input>
                    <label className="form-check-label" for="remember">Se souvenir de moi</label>
                    <br></br>
                    <small class="text-muted">La session durera une heure si vous ne cochez pas cette case.</small>
                </div>
                {error && <p style={{ color: "red" }}>{error}</p>}
                <center><button type="submit" className="btn btn-danger">Connexion</button></center>
            </form>
        </div>
    );
}

export default Login;