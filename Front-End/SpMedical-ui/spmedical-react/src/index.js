import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Routes,
} from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/auth';

//Páginas:
import Login from './Pages/Login/Login'
import Home from './Pages/Home/Home'
import ListarConsultas from './Pages/ListarConsultas/ListarConsultas';
import NovaConsulta from './Pages/NovaConsulta/NovaConsulta';

import reportWebVitals from './reportWebVitals';



ReactDOM.render(
  <React.StrictMode>
    <NovaConsulta />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
