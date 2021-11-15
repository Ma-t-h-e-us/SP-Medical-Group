import { Component } from 'react';
import { useState, useEffect } from 'react';
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

export default function ListarConsultas() {
    const [listaConsultas, setListaConsultas] = useState([]);

    function listarConsultas() {
        axios('http://localhost:5000/api/Consultas/Listar/Minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultas(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    };

    useEffect(listarConsultas, []);

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
                        {listaConsultas.map((consulta => {
                            return (
                                <div className="cadaConsulta_ListarConsultas">
                                    <div className="span_ListarConsultas">
                                        <span>Médico:</span>
                                        <p>{consulta.IdMedicoNavigation.Nome}</p>
                                    </div>
                                    <div className="span_ListarConsultas">
                                        <span>Paciente:</span>
                                        <p>{consulta.IdPacienteNavigation.NomePaciente}</p>
                                    </div>
                                    <div className="span_ListarConsultas">
                                        <span>{consulta.DataConsulta}</span>
                                    </div>
                                    <div className="span_ListarConsultas">
                                        <span>{consulta.IdSituacaoNavigation.Descricao}</span>
                                    </div>
                                    <svg height="33px" width="26px">
                                        <a href=""><polygon points="0,0 26,0 13,33" className="setinhaConsultas" /></a>
                                    </svg>
                                </div>
                            )
                        }))}
                    </div>
                </section>
            </main>
            <Footer />
        </div>
    );
}
