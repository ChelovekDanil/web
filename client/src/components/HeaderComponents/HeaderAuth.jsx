import { Link } from "react-router-dom";

function HeaderAuth() {
    const click = () => {
        localStorage.setItem("isAuth", false);
    }

    return (
        <>
            <div className='NavigateBlock'>
                <Link to='/popularmovies' className='linkNav' id='popular'>Popular</Link>
                <Link to='/films' className='linkNav' id='film'>Films</Link>
                <Link to='/serials' className='linkNav' id='serial'>Serials</Link>
            </div>
            <div className="AuthBlock">
                <p className='linkAuth' id='logIn' onClick={click}>Me</p>
            </div>
        </>
    )
}

export default HeaderAuth;