import React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';

import './App.css';
import 'rsuite/dist/styles/rsuite-dark.css';

import HomePage from './pages/Home';
import ExamPage from './pages/Exam';
import ErrorPage from './pages/Error';
import ProfilePage from './pages/Profile';
import LoginPage from './pages/Login';
import RegisterPage from './pages/Register';

import GlobalContext from './contexts/GlobalContext';

const App = () => {
    return (
        <GlobalContext.Provider value={{ examAttemptId: null }}>
            <Switch>
                <Route path="/" exact component={HomePage}></Route>
                <Route path="/Exam/:id" component={ExamPage}></Route>
                <Route path="/Profile" exact component={ProfilePage}></Route>
                <Route path="/Login" exact component={LoginPage}></Route>
                <Route path="/Register" exact component={RegisterPage}></Route>

                <Route
                    path="/logout"
                    render={() => {
                        return <Redirect to="/" />;
                    }}
                ></Route>

                <Route component={ErrorPage}></Route>
            </Switch>
        </GlobalContext.Provider>
    );
};

export default App;
