import * as React from 'react';
//import { styled } from '@mui/material/styles';
//import Button from '@mui/material/Button';
// import IconButton from '@mui/material/IconButton';
// import PhotoCamera from '@mui/icons-material/PhotoCamera';
//import Stack from '@mui/material/Stack';
import axios from 'axios';
import { useState } from 'react';

/*
const Input = styled('input')({
    display: 'none',
});
*/
export default function Uploads() {
    const [success, setSuccess] = useState(0)
    const [failures, setFailed] = useState(0)

    return (
        /*<div id="result-grid">
            <span>Please Select a CSV file to upload</span>
            <Stack direction="row" alignItems="center" spacing={2}>
                <label htmlFor="contained-button-file">
                    <Input accept="text/csv" id="contained-button-file" type="file" onChange={x => {
                        let data = new FormData()
                        data.append("file", x.target.files[0])
                        console.log("🚀 ~ file: Upload.jsx ~ line 20 ~ Uploads ~ x.target.files", x.target.files)
                        axios.post("/meter-reading-uploads", data).then(resp => {
                            let { data } = resp
                            console.log("🚀 ~ file: Upload.jsx ~ line 29 ~ axios.post ~ data", data)
                            setSuccess(data.successes)
                            setFailed(data.failures)
                        }).catch(err => {
                        })
                    }} />
                    <Button variant="contained" component="span">
                        Upload
                    </Button>
                </label>
                {/* <label htmlFor="icon-button-file">
                <Input accept="image/*" id="icon-button-file" type="file" />
                <IconButton color="primary" aria-label="upload picture" component="span">
                    <PhotoCamera />
                </IconButton>
            </label> *//*}
            </Stack>
            <span>Results</span>
            <Stack direction={"row"} alignItems={"center"} spacing={2}>
                <div style={{
                    fontStyle: "bold"
                }}>Successful Readings: {success}</div>
                <div style={{
                    fontStyle: "bold"
                }}>Failed Readings: {failures}</div>
            </Stack>
        </div>*/
        <div>
            <button onClick={x => {
                        let data = new FormData()
                        //data.append("file", x.target.files[0])
                        //console.log("🚀 ~ file: Upload.jsx ~ line 20 ~ Uploads ~ x.target.files", x.target.files)
                        axios.get("/WeatherForecast").then(resp => {
                            let { data } = resp
                            console.log("🚀 ~ file: Upload.jsx ~ line 29 ~ axios.get ~ data", data)
                            //setSuccess(data.successes)
                            //setFailed(data.failures)
                        }).catch(err => {
                        })
                    }}> ghaday </button>

        </div>
    );
}
