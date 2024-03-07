import { useState } from 'react';
import './Join.css'
import { Link, useNavigate } from 'react-router-dom';
import AuthAxios from '../axios/AuthAxios';

function Join() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [repeatPassword, setRepeatPassword] = useState("");
    const navigate = useNavigate();

    const ChangeUsername = (e) => {
        setUsername(e.target.value);
    }

    const ChangePassword = (e) => {
        setPassword(e.target.value);
    }

    const ChangeRepeatPassword = (e) => {
        setRepeatPassword(e.target.value);
    }

    // for registration
    const Click = () => {
        let isGood = true;

        if (username === "" || password === "") {
            alert("Enter all fields")
            isGood = false;
        }

        if (password !== repeatPassword) {
            alert("Password mismatch")
            isGood = false;
        }

        if (password.length <= 8) {
            alert("Enter larger password")
            isGood = false
        }

        if (isGood) {
            AuthAxios(username, password, "https://localhost:7261/api/auth/registration")
                .then(success => {
                    if (success) {
                        localStorage.setItem("isAuth", true);
                        navigate("/popularmovies", {replace: true});
                    }
                    else {
                        localStorage.setItem("isAuth", false);
                    }
                });
            }
    }

    return (
        <div className="EnterWindow">
            <p className="Join">Join</p>
            <input type="text" className="input" value={username} onChange={ChangeUsername} placeholder='Username'/>
            <input type="password" className="input" value={password} onChange={ChangePassword} placeholder='Password'/>
            <input type="password" className="input" value={repeatPassword} onChange={ChangeRepeatPassword} placeholder='Repeat password'/>
            <Link to="/login" className="GoToLogin">Login</Link>
            <p className="enter" onClick={() => {Click()}}>Enter</p>
        </div>
    );
}
  
export default Join;