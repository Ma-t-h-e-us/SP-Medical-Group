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

        if (usuarioAutenticado() && parseJwt().role === '1') {
            axios('http://localhost:5000/api/Consultas', {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
                .then(resposta => {
                    if (resposta.status === 200) {
                        console.log(resposta.data);
                        setListaConsultas(resposta.data);
                        console.log(listaConsultas);
                    }
                })

                .catch(erro => console.log(erro))

        } else {
            axios('http://localhost:5000/api/Consultas/Listar/Minhas', {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
                .then(resposta => {
                    if (resposta.status === 200) {
                        console.log(resposta.data.listaConsultas);
                        setListaConsultas(resposta.data.listaConsultas);
                        console.log(listaConsultas);
                    }
                })

                .catch(erro => console.log(erro))
        }

    };

    function renderSwitch(param) {
        switch (param) {
            case 1:
                return <p style = {{color : '#02D66D', fontWeight : 'bold'}} >Realizada</p>     
            case 2:
                return <span style = {{color : 'red'}}>Cancelada</span>
            case 3:
                return <span style = {{color : 'blue'}}>Ajendada</span>
            default:
                return <span>Status desconhecido</span>
        }
    }

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
                        {listaConsultas.map((consulta) => {
                            return (
                                <div key={consulta.idConsulta}>
                                    <div className="cadaConsulta_ListarConsultas">
                                        <div className="span_ListarConsultas">
                                            <span>Médico:</span>
                                            <p key={consulta.idConsulta}>{consulta.idMedicoNavigation.nome}</p>
                                        </div>
                                        <div className="span_ListarConsultas">
                                            <span>Paciente:</span>
                                            <p key={consulta.idConsulta}>{consulta.idPacienteNavigation.nomePaciente}</p>
                                        </div>
                                        <div className="span_ListarConsultas">
                                            <span key={consulta.idConsulta}>{consulta.dataConsulta}</span>
                                        </div>
                                        <div className="span_ListarConsultas">
                                            {consulta.descricao == '' ? <span style ={{color : 'red', opacity : 0.6}}>Sem descricao</span> : <span>{consulta.descricao}</span>}
                                        </div>
                                        <div className="span_ListarConsultas">
                                            {renderSwitch(consulta.idSituacao)}
                                        </div>
                                        <svg height="33px" width="26px">
                                            <a href=""><polygon points="0,0 26,0 13,33" className="setinhaConsultas" /></a>
                                        </svg>
                                    </div>
                                </div>
                            )
                        })}
                    </div>
                </section>
            </main>
            <Footer />
        </div>
    );
}
