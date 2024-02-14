import { useState } from 'react';
import './Join.css'
import { Link } from 'react-router-dom';

function Join() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const ChangeUsername = (e) => {
        setUsername(e.target.value);
    }

    const ChangePassword = (e) => {
        setPassword(e.target.value);
    }

    return (
        <div className="EnterWindow">
            <p className="Join">Join</p>
            <input type="text" className="input" value={username} onChange={ChangeUsername} placeholder='Username'/>
            <input type="password" className="input" value={password} onChange={ChangePassword} placeholder='Password'/>
            <Link to="/login" className="GoToLogin">Login</Link>
            <p className="enter" onClick={() => {console.log("click");}}>Enter</p>
        </div>
    );
  }
  
export default Join;