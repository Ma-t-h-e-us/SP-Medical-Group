import React, { Component } from "react";

class Footer extends Component {
    render() {
        return (
            <section class="footer">
                <div class="fundoFooter"></div>
                <div class="conteudoFooter container">
                    <div class="insta">
                        <img src="../assets/instagram.png" alt="instagram"></img>
                        <p>@SPMG</p>
                    </div>
                    <div class="logoFooter">
                        <img src="../assets/logoSubtitulo.png" alt=""></img>
                        <p>SP.Medical.group@gmail.com</p>
                    </div>
                    <div class="twitter">
                        <img src="../assets/twitter.png" alt="twitter"></img>
                        <p>@SPMG</p>
                    </div>
                </div>
            </section>
        )
    }
}
export default Footer