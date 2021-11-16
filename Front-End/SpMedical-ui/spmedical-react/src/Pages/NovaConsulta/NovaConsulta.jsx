import { Component } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import { render } from '@testing-library/react';

//css:
import '../../assets/css/NovaConsulta.css';
import '../../assets/css/Footer.css';
import '../../assets/css/Header.css';

//Componentes:
import HeaderComum from '../../Components/Header/HeaderComum'
import Footer from '../../Components/Footer/footer'

//img:
import undraw_doctor2 from '../../assets/img/undraw_doctor2.png'

export default class NovaConsulta extends Component {
    constructor(props) {
        super(props);
        this.state = {
            crm: 0,
            cpf: 0,
            data: new Date(),
            descricao: '',
            errorMessage: '',
            loading: false
        }
    }

    cadastrarConsulta = (event) => {
        event.preventDefault();
        this.setState({ loading: true })

        let consulta = {
            crm: this.state.crm,
            cpf: this.state.cpf,
            data: this.state.data,
            descricao: this.state.descricao
        }

        axios
            .post('http://localhost:5000/api/Consultas', consulta, {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Consulta cadastrada!');
                    this.setState({ loading : false });
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({ 
                    errorMessage : 'Dados inválidos',
                    loading : false });
            })
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    }

render() {
    return (
        <div>
            <HeaderComum />
            <div class="conteudo container">
                <img src={undraw_doctor2} alt="desenho médico com paciente" width="775px" height="645px"></img>
                <div class="dadosConsulta">
                    <h1>Dados da Consulta</h1>
                    <hr></hr>
                    <form action="" class="formularioCadastroConsulta" onSubmit={this.cadastrarConsulta}>
                        <input type="text" value={this.state.crm} onChange={this.atualizaStateCampo} name="crm" id="" placeholder="CRM do médico"></input>
                        <input type="number" value={this.state.cpf} onChange={this.atualizaStateCampo} name="cpf" placeholder="CPF do paciente"></input>
                        <input type="date" value={this.state.data} onChange={this.atualizaStateCampo} name="data" placeholder="Data"></input>
                        <input type="text" value={this.state.descricao} onChange={this.atualizaStateCampo} name="descricao" placeholder="Descrição"></input>
                        <p style={{ color: 'red' }}>{this.state.errorMessage}</p>
                            {
                                this.state.loading === true && (
                                    <button type="submit" disabled>Loading...</button>
                                )
                            }
                            {
                                 this.state.loading === false && (
                                    <button type="submit"
                                        disabled={
                                            this.state.crm === '' || this.state.cpf === '' || this.state.data === '' || this.state.descricao === ''
                                                ? 'none'
                                                : ''
                                        }
                                    >Cadastar</button>
                                )
                            }
                    </form>
                </div>
            </div>
            <Footer />
        </div>
    );
}
}