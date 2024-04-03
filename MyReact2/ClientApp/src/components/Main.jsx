import React, { useState, useEffect, useRef } from "react";
import { SearchOutlined } from '@ant-design/icons';
import 'antd/dist/reset.css';
import { Select, Button, Space, Table, Input, DatePicker, Tag, Modal } from 'antd';
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
            <Modal>

            </Modal>
            <Space
                direction="horizontal"
            >
                <Button
                    onClick={() => {
                        fetchData();
                    }}
                    icon={<SearchOutlined />}
                    style={{
                        color: 'red', fontWeight: 'bold'
                    }}
                >
                    Найти
                </Button>

            </Space>
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