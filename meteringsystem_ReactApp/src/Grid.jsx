import { DataGrid } from '@mui/x-data-grid';

// const rows: GridRowsProp = [
// { id: 1, col1: 'Hello', col2: 'World' },
// { id: 2, col1: 'DataGridPro', col2: 'is Awesome' },
// { id: 3, col1: 'MUI', col2: 'is Amazing' },
// ];

const columns = [
    { field: 'accountId', headerName: 'Account Id', width: 150 },
    { field: 'meterReadValue', headerName: 'Meter Read Value', width: 200 },
    { field: 'meterReadingDateTime', headerName: 'Meter Reading Date-Time', width: 200 },
    { field: 'result', headerName: 'Result', width: 100 },
];

const rowFunc = (x) => {
    console.log("🚀 ~ file: Grid.jsx ~ line 17 ~ rowFunc ~ x", x)
    return x.map((y, i) => {
        return {
            ...y,
            id: i
        }
    })
}

export default function ResultGrid(props) {
    return <div style={{ height: '70vh', width: '90%' }}>
        <DataGrid rows={rowFunc(props.rows)} columns={columns} pageSize={10} />
    </div>
}