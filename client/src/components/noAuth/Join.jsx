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

    const Click = () => {
        if (username !== "" || password !== "") {
            if (password === repeatPassword) {
                if (password.length > 8) {
                    AuthAxios(username, password, "https://localhost:7261/api/auth/registration");
                    navigate("/popularmovies");
                }
                else {
                    alert("Enter larger password")
                }
            }
            else {
                alert("Password mismatch")
            }
        }
        else {
            alert("Enter all fields")
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