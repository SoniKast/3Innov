import React from 'react';

const Login = () => {
  return (
      <div className="main-page">
          <h1 className="text-center">
              Connexion
          </h1>
          <form className="login-form col-3">
              <div className="form-group">
                  <label for="emailAddress">Adresse mail</label>
                  <input type="email" className="form-control" id="emailAddress" placeholder="Entrer son email"></input>
              </div>
              <div className="form-group">
                  <label for="exampleInputPassword1">Mot de passe</label>
                  <input type="password" className="form-control" id="idPassword" placeholder="Mot de passe"></input>
              </div>
              <div className="form-group form-check">
                  <input type="checkbox" className="form-check-input" id="remember"></input>
                  <label className="form-check-label" for="remember">Se souvenir de moi</label>
              </div>
              <center><button type="submit" className="btn btn-danger">Connexion</button></center>
          </form>
      </div>
  );
}

export default Login;