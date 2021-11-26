import * as React from 'react';
import { styled } from '@material-ui/styles';
import Button from '@material-ui/core/Button';
import Stack from '@material-ui/core/Stack';
import axios from 'axios';
import { useState } from 'react';
import ResultGrid from './Grid';

const Input = styled('input')({
    display: 'none',
});

export default function Uploads() {
    const [success, setSuccess] = useState(0)
    const [failures, setFailed] = useState(0)
    const [resultList, setResultList] = useState([])

    return (
        <div id="result-grid">
            <span>Please Select a CSV file to upload</span>
            <Stack direction="row" alignItems="center" spacing={2}>
                <label htmlFor="contained-button-file">               
                    <Input accept="text/csv" id="contained-button-file" type="file" onChange={x => {
                        let data = new FormData()
                        data.append("file", x.target.files[0])
                        console.log("🚀 ~ file: Upload.jsx ~ line 20 ~ Uploads ~ x.target.files", x.target.files)
                        setResultList([])
                        axios.post("/meter-reading-uploads", data).then(resp => {
                            alert("successfully uploaded")
                            let { data } = resp
                            setSuccess(data.successes)
                            setFailed(data.failures)
                            setResultList(data.rows)
                            console.log("🚀 ~ file: Upload.jsx ~ line 32 ~ axios.post ~ data.rows", data.rows)
                            document.getElementById("contained-button-file").value = "";
                        }).catch(err => {
                            alert("Could not upload and process file")
                        })
                    }} />
                    <Button variant="contained" component="span">
                        Upload
                    </Button>
                </label>
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
            <div>
                <ResultGrid success={success} failures={failures} rows={resultList} />
            </div>
        </div>
    );
}
