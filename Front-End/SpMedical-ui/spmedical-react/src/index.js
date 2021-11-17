import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/auth';

//Páginas:
import Login from './Pages/Login/Login.jsx'
import Home from './Pages/Home/Home.jsx'
import ListarConsultas from './Pages/ListarConsultas/ListarConsultas';
import NovaConsulta from './Pages/NovaConsulta/NovaConsulta';
import NotFound from './Pages/NotFound/NotFound';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      )
    }
  />
);

const PermissaoPaciente = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        <Component {...props} />
      ) : (
        <Redirect to="/Home" />
      )
    }
  />
);
const PermissaoMedico = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="/Home" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} /> {/* Home */}
        <Route path="/Home" component={Home} /> {/* Login */}
        <Route path="/Login" component={Login} /> {/* Login */}
        <Route path="/ListarConsultas" component={ListarConsultas} /> {/* ListarConsultas  */}
        <PermissaoAdm path="/NovaConsulta" component={NovaConsulta} /> 
        <Route path="/NotFound" component={NotFound} /> {/* Página não encontrada  */}
        <Redirect to="/NotFound" />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// ReactDOM.render(
//   <React.StrictMode>
//     <ListarConsultas />
//   </React.StrictMode>,
//   document.getElementById('root')
// );

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
