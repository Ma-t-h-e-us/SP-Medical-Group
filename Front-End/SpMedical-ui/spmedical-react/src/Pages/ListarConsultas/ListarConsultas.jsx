import { Component } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import { render } from '@testing-library/react';

//css:
import '../../assets/css/ListarConsultas.css';
import '../../assets/css/Footer.css';
import '../../assets/css/Header.css';

//Componentes:
import HeaderComum from '../../Components/Header/HeaderComum'
import HeaderAdm from '../../Components/Header/HeaderAdm'
import Footer from '../../Components/Footer/footer'

export default class ListarConsultas extends Component {
    render() {
        return (
            <div>
                <HeaderComum />
                <main className="main_ListarConsultas">
                    <section className="consultas_ListarConsultas">
                        <div className="tituloConsultas_ListarConsultas">
                            <h1>Consultas</h1>
                            <hr></hr>
                        </div>
                        <div className="areaConsultas_ListarConsultas">
                            <div className="cadaConsulta_ListarConsultas">
                                <div className="span_ListarConsultas">
                                    <span>Médico:</span>
                                    <p>O Brabo</p>
                                </div>
                                <div className="span_ListarConsultas">
                                    <span>Paciente:</span>
                                    <p>João</p>
                                </div>
                                <div className="span_ListarConsultas">
                                    <span>XX/XX/XX</span>
                                </div>
                                <div className="span_ListarConsultas">
                                    <span>Agendada</span>
                                </div>
                                <svg height="33px" width="26px">
                                    <a href=""><polygon points="0,0 26,0 13,33" className="setinhaConsultas" /></a>
                                </svg>
                            </div>
                        </div>
                    </section>
                </main>
                <Footer />
            </div>
        );
    }
}