import { Component } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import { render } from '@testing-library/react';

//css:
import '../../assets/css/Home.css';
import '../../assets/css/Footer.css';
import '../../assets/css/Header.css';

//Componentes:
import HeaderComum from '../../Components/Header/HeaderComum'
import HeaderAdm from '../../Components/Header/HeaderAdm'
import Footer from '../../Components/Footer/footer'

//Img:
import maoMedicos from '../../assets/img/maoMedicos.png'
import undraw_doctors from '../../assets/img/undraw_doctors.png'

export default class Home extends Component {
    render() {
        return (
            <div>
                <HeaderAdm />
                <main className="mainHome">
                    <section className="Banner1">
                        <div className="fundoBanner"></div>
                    </section>
                    <section className="Banner2">
                        <img src={maoMedicos} className="maoMedicos" alt="mão de médicos com luvas"></img>
                        <button>Ver Consultas</button>
                    </section>
                    <section className="SobreNos container">
                        <div className="ConteudoSobreNos">
                            <h1>Sobre Nós</h1>
                            <hr></hr>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
                                industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type
                                and scrambled it to make a type specimen book.
                            </p>
                        </div>
                        <img src={undraw_doctors} alt="médicos em formato de desenho" height="500px"></img>
                    </section>
                    <section className="UseMascara">
                        <h1>USE MÁSCARA</h1>
                    </section>
                </main>
                <Footer />
            </div>
        );
    }
}