import React, { Component } from "react";

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
                        <img src={instagram} alt="instagram"></img>
                        <p>@SPMG</p>
                    </div>
                    <div class="logoFooter">
                        <img src={logoSubtitulo} alt=""></img>
                        <p>SP.Medical.group@gmail.com</p>
                    </div>
                    <div class="twitter">
                        <img src={twitter} alt="twitter"></img>
                        <p>@SPMG</p>
                    </div>
                </div>
            </section>
        )
    }
}
export default Footer