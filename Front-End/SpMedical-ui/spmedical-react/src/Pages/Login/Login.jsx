import { Component } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import { render } from '@testing-library/react';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            errorMessage : '',
            loading : false,
        };
    }

    efetuarLogin = (event) => {
        event.preventDefault();
        this.setState({ errorMessage : '', loading : true});
        axios .post('http://localhost:5000/api/Login', 
        {
            email: this.state.email,
            senha: this.state.senha,
        }
        )

        .then((resposta) => {
            if (resposta.status === 200 ) {
                localStorage.setItem('usuario-login', resposta.data.token);
                this.setState({loading: true});
                //Base64 recebe o payload do token
                let base64 = localStorage.getItem('usuario-login').split('.')[1];
                console.log(base64);
                console.log(this.props);

                this.props.history.push('/Home');
            }
        })

        .catch(() => {
            this.setState({
                errorMessage: 'Email ou senha inválidos, tente novamente',
                loading: false
            });
        });
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    }
}

render()
{
    return (
        <main>
            <section class="areaFormularioLogin">
                <img src="../assets/logoSubtitulo.png" alt="logoSubtitulo"></img>
                <form class="formularioLogin" onsubmit={this.efetuarLogin()}>
                    <input type="email" value={this.state.email} onChange={this.atualizaStateCampo()} placeholder="Email"></input>
                    <input type="password" value={this.state.senha} onChange={this.atualizaStateCampo()} placeholder="Senha"></input>
                    {
                        this.state.loading === true && (
                            <button type="submit" disabled>Loading...</button>  
                        )
                    }
                    {
                        this.state.loading === true && (
                            <button type="submit"
                            disabled={
                                this.state.email === '' || this.state.senha === ''
                                  ? 'none'
                                  : ''
                              }
                            >Login</button>  
                        )
                    }
                    <div class="linhaEsqueceuSenha">
                        <hr></hr>
                        <a href="">Esqueceu sua senha?</a>
                        <hr></hr>
                    </div>
                </form>
            </section>
        </main>
    )
}