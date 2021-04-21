import React from 'react';

interface IGlobal {
    examAttemptId: number | null;
}

const initialContext: IGlobal = {
    examAttemptId: null,
};

const GlobalContext = React.createContext<IGlobal>(initialContext);

export default GlobalContext;