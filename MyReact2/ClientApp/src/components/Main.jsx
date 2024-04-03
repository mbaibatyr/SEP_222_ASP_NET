import React, { useState, useEffect, useRef } from "react";
import { SyncOutlined, MessageOutlined, PhoneOutlined, MailOutlined } from '@ant-design/icons';
import 'antd/dist/reset.css';
import { Select, Button, Space, Table, Input, DatePicker, Tag } from 'antd';
import dayjs from 'dayjs';
import "./table.css"

const Main = () => {
    let columns = [
        {
            title: 'id',
            dataIndex: 'id',
            key: 'id'
        },
        {
            title: 'name',
            dataIndex: 'name',
            key: 'name'
        }
    ];


    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchData = () => {
        setLoading(true);
        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        };
        fetch(`My/GetCity`, requestOptions)
            .then(response => {
                return response.json()
            })
            .then(data => {
                setLoading(false);
                setData(data)
            })
    }

    useEffect(() => {
        fetchData();
    }, []);

    return (
        <div>
            <Table
                dataSource={data}
                columns={columns}
                pagination={{
                    position: ["topRight"],
                    showSizeChanger: true,
                    defaultPageSize: 15,
                    pageSizeOptions: ["15", "50", "100", "200"]
                }}
                loading={loading}
                size="small"
                className="table-striped-rows"
            />

        </div >

    )
}
export default Main