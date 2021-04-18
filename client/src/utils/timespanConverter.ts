class TimeSpanConvert {
    convertFromStringInMs(timespan: string): Date {
        let date = new Date(Date.now() + parseInt(timespan));

        return date;
    }
}

export default new TimeSpanConvert();