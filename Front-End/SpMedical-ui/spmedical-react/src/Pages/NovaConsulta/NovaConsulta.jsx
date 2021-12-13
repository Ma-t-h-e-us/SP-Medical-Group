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
            idMedico: '',
            idPaciente: '',
            idSituacao: 0,
            dataConsulta: new Date(),
            descricao: '',
            errorMessage: '',
            loading: false
        }
    }

    cadastrarConsulta = (event) => {
        event.preventDefault();
        this.setState({ loading: true })

        let consulta = {
            idMedico: this.state.idMedico,
            idPaciente: this.state.idPaciente,
            idSituacao: 3,
            dataConsulta: this.state.dataConsulta,
            descricao: this.state.descricao
        }

        this.setState({ loading: true });

        axios
            .post('http://localhost:5000/api/Consultas', consulta, {
                headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Consulta cadastrada!');
                    this.setState({
                        idMedico: '',
                        idPaciente: '',
                        idSituacao: 0,
                        dataConsulta: new Date(),
                        descricao: '',
                        errorMessage: '',
                        loading: false
                    });
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({
                    errorMessage: 'Dados inválidos',
                    loading: false
                });
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
                            <input type="text" value={this.state.idMedico} onChange={this.atualizaStateCampo} name="idMedico" id="" placeholder="ID do médico"></input>
                            <input type="text" value={this.state.idPaciente} onChange={this.atualizaStateCampo} name="idPaciente" placeholder="ID do paciente"></input>
                            <input type="date" value={this.state.dataConsulta} onChange={this.atualizaStateCampo} name="dataConsulta" placeholder="Data"></input>
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
                                            this.state.idMedico === '' || this.state.idPaciente === '' || this.state.dataConsulta === '' || this.state.descricao === ''
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