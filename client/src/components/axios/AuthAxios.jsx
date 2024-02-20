import axios from 'axios';  

function AuthAxios(username, password, url) {
    axios.post(url, 
        {
            Username: username,
            Password: password
        },
        {withCredentials: true})
        .then(response => {
            if (response.status === 200 || response.status === 201) {
                localStorage.setItem("access_token", JSON.stringify(response.data.accessToken));
                localStorage.setItem("user_name", JSON.stringify(response.data.username));
                return true;
            }
            else {
                return false;
            }
        });
}

export default AuthAxios;