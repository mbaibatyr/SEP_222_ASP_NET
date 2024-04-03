import React, { useState, useEffect, useRef } from "react";
import { SearchOutlined } from '@ant-design/icons';
import 'antd/dist/reset.css';
import { Select, Button, Space, Table, Input, DatePicker, Tag, Modal, notification } from 'antd';
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
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [id, setId] = useState('');


    const fetchData = () => {
        setLoading(true);
        var id2 = '';
        if (id == '' || id == null) {
            id2 = 'all';
        }
        else {
            id2 = id;
        }


        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        };
        fetch(`My/GetCityAll/${id2}`, requestOptions)
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
            <Modal
                title="Basic Modal"
                open={isModalOpen}
                onOk={() => {
                    setIsModalOpen(false);
                }}
                onCancel={() => {
                    setIsModalOpen(false);
                }}>

                <p>Some contents...</p>
                <p>Some contents...</p>
                <p>Some contents...</p>
            </Modal>
            <Space
                direction="horizontal"
            >
                <Input
                    placeholder="Введите id или all"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    style={{
                        width: 50
                    }}
                />
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

                <Button
                    onClick={() => {
                        setIsModalOpen(true);
                    }}
                    icon={<SearchOutlined />}
                    style={{
                        color: 'red', fontWeight: 'bold'
                    }}
                >
                    Открыть модальное окно
                </Button>

                <Button
                    onClick={() => {
                        notification.error({
                            message: "Info",
                            description: (
                                <>
                                    Title is empty
                                </>
                            )
                        });
                    }}
                    icon={<SearchOutlined />}
                    style={{
                        color: 'red', fontWeight: 'bold'
                    }}
                >
                    Открыть нотификауция
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