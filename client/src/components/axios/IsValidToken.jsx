import axios from 'axios';

function IsValidToken() {
    const token = JSON.parse(localStorage.getItem("access_token"));

    axios.get('https://localhost:7261/api/validateaccesstoken', {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
    .then(response => {
        response.status === 200 ? true : false;
    })
}

export default IsValidToken();