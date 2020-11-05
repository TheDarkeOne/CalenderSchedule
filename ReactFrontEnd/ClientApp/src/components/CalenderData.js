import React, { Component } from 'react';

/*import axios from 'axios';*/
import { FormGroup } from 'reactstrap';

export class CalenderData extends Component {
    static displayName = CalenderData.name;

    constructor(props) {
        super(props);
        this.state = {
            calenders: [],
            scheduleName: '',
            day: '',
            month: '',
            year: '',
            time: '',
            description: '',
            loading: true
        };

        this.handleChangeName = this.handleChangeName.bind(this);
        this.handleChangeDay = this.handleChangeDay.bind(this);
        this.handleChangeMonth = this.handleChangeMonth.bind(this);
        this.handleChangeYear = this.handleChangeYear.bind(this);
        this.handleChangeTime = this.handleChangeTime.bind(this);
        this.handleChangeDescription = this.handleChangeDescription.bind(this);
        this.Addstudent = this.Addstudent.bind(this);
    }

    handleChangeName(event) {
        this.setState({ scheduleName: event.target.scheduleName });
    }

    handleChangeDay(event) {
        this.setState({ day: event.target.day });
    }
    handleChangeMonth(event) {
        this.setState({ month: event.target.month });
    }
    handleChangeYear(event) {
        this.setState({ year: event.target.year });
    }

    handleChangeTime(event) {
        this.setState({ time: event.target.time });
    }

    handleChangeDescription(event) {
        this.setState({ description: event.target.description });
    }

    Addstudent() {
        /*axios.post('http://localhost:5005/api/calender/addcalender', {
            Name: this.state.scheduleName, Day: this.state.day,
            Time: this.state.time, Description: this.state.description
        })*/

        /*// creates entity
        fetch("http://localhost:5005/api/calender/addcalender", {
            "method": "POST",
            "body": JSON.stringify(body)
        })*/
    }

    componentDidMount() {
        this.populateCalenderData();
    }

    static renderScheduleTable(calenders) {
        return (
            <div>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Month</th>
                            <th>Day</th>
                            <th>Year</th>
                            <th>Time</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        {calenders.map(calenders =>
                            <tr key={calenders.id}>
                                <td>{calenders.id}</td>
                                <td>{calenders.name}</td>
                                <td>{calenders.month}</td>
                                <td>{calenders.day}</td>
                                <td>{calenders.year}</td>
                                <td>{calenders.time}</td>
                                <td>{calenders.description}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CalenderData.renderScheduleTable(this.state.calenders);

        return (
            <div>
                <h1 id="tabelLabel" >Calender Data</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateCalenderData() {
        /*axios.get(`http://localhost:5005/api/calender`)
            .then(res => {
                this.setState({ calenders: res.data, loading: false });
            })*/

        await fetch('http://localhost:5005/api/calender', {
            "method": "GET"
            })
            .then(res => res.json())
            .then((data) => {
                this.setState({ calenders: data, loading: false })
            })
            .catch(console.log)
    }
}
