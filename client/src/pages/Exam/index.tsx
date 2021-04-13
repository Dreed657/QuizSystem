import React from 'react';
import ExamSidebar from '../../components/ExamSidebar/Index';

import { Placeholder, Grid, Row, Col, Loader } from 'rsuite';

const ExamPage = () => {
    const { Paragraph } = Placeholder;

    return (
        <Grid fluid>
            <Row className="show-grid">
                <Col xs={4}>
                    <h3>Exam Page.</h3>
                    <ExamSidebar></ExamSidebar>
                </Col>
                <Col xs={8}>
                    <Paragraph style={{ marginTop: 30 }} graph="circle" />
                    <Paragraph style={{ marginTop: 30 }} graph="square" />
                    <Paragraph style={{ marginTop: 30 }} graph="image" />
                </Col>
            </Row>
            <Loader size="lg" content="Loading..."/>
        </Grid>
    );
};

export default ExamPage;
