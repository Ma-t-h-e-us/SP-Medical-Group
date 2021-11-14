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
import HeaderAdm from '../../Components/Header/HeaderAdm'
import Footer from '../../Components/Footer/footer'

//img:
import undraw_doctor2 from '../../assets/img/undraw_doctor2.png'

export default class NovaConsulta extends Component {
    render() {
        return (
            <div>
                <HeaderAdm />
                <div class="conteudo container">
                    <img src={undraw_doctor2} alt="desenho médico com paciente" width="775px" height="645px"></img>
                    <div class="dadosConsulta">
                        <h1>Dados da Consulta</h1>
                        <hr></hr>
                        <form action="" class="formularioCadastroConsulta">
                            <input type="number" name="" id="" placeholder="CRM do médico"></input>
                            <input type="number" placeholder="CPF do paciente"></input>
                            <input type="date" placeholder="Data"></input>
                            <input type="text" placeholder="Descrição"></input>
                            <button>Cadastrar</button>
                        </form>
                    </div>
                </div>
                <Footer />
            </div>
        );
    }
}