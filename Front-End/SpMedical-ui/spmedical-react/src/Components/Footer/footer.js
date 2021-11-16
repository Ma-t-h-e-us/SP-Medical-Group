import React, { Component } from "react";
import { Link } from 'react-router-dom';

//img:
import instagram from '../../assets/img/instagram.png'
import logoSubtitulo from '../../assets/img/logoSubtitulo.png'
import twitter from '../../assets/img/twitter.png'

class Footer extends Component {
    render() {
        return (
            <section class="footer">
                <div class="fundoFooter"></div>
                <div class="conteudoFooter container">
                    <div class="insta">
                        <Link to="/Home"><img src={instagram} alt="instagram"></img></Link>    
                        <p>@SPMG</p>
                    </div>
                    <div class="logoFooter">
                        <img src={logoSubtitulo} alt=""></img>
                        <p>SP.Medical.group@gmail.com</p>
                    </div>
                    <div class="twitter">
                        <Link to="/Home"><img src={twitter} alt="twitter"></img></Link>
                        <p>@SPMG</p>
                    </div>
                </div>
            </section>
        )
    }
}
export default Footer