import React, { Component } from 'react';

export class CalenderData extends Component {
    static displayName = CalenderData.name;

    constructor(props) {
        super(props);
        this.state = {
            calenders: [],
            scheduleName: "defualt",
            day: "2019-07-26T00:00:00",
            time: "2019-07-26T00:01:00",
            description: "default",
            loading: true};
        this.create = this.create.bind(this);
    }

    create(e) {
        // add entity - POST
        e.preventDefault();
        // creates entity
        fetch("http://localhost:5005/api/calender/addcalender", {
            "method": "POST",
            "headers": {
                "content-type": "application/json"
            },
            "body": JSON.stringify({
                name: this.state.scheduleName,
                day: this.state.day,
                time: this.stat.time,
                description: this.state.description
            })
        })
            .then(response => response.json())
            .then(response => {
                console.log(response)
            })
            .catch(err => {
                console.log(err);
            });
    }

    componentDidMount() {
        this.populateCalenderData();
    }

    static renderScheduleTable(calenders) {
        return (
            <body>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Day</th>
                            <th>Time</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        {calenders.map(calenders =>
                            <tr key={calenders.id}>
                                <td>{calenders.id}</td>
                                <td>{calenders.name}</td>
                                <td>{calenders.day}</td>
                                <td>{calenders.time}</td>
                                <td>{calenders.description}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <form className="d-flex flex-column">
                    <legend className="text-center">Add Schedule To Calender</legend>
                    <label htmlFor="scheduleName">
                        Schedule Name:
                  <input
                            name="scheduleName"
                            id="scheduleName"
                            type="text"
                            className="form-control"
                            value="defualt"
                            onChange={(e) => this.handleChange({ scheduleName: e.target.value })}
                            required
                        />
                    </label>
                    <label htmlFor="day">
                        Schedule Day:
                  <input
                            name="day"
                            id="day"
                            type="datetime"
                            className="form-control"
                            value="2019-07-26T00:00:00"
                            onChange={(e) => this.handleChange({ day: e.target.value })}
                            required
                        />
                    </label>
                    <label htmlFor="time">
                        Schedule Name:
                  <input
                            name="time"
                            id="time"
                            type="datetime"
                            className="form-control"
                            value="2019-07-26T00:01:00"
                            onChange={(e) => this.handleChange({ time: e.target.value })}
                            required
                        />
                    </label>
                    <label htmlFor="description">
                        Schedule Day:
                  <input
                            name="description"
                            id="description"
                            type="text"
                            className="form-control"
                            value="defualt"
                            onChange={(e) => this.handleChange({ description: e.target.value })}
                            required
                        />
                    </label>
                    <button className="btn btn-primary" type='button' onClick={(e) => this.create(e)}>
                        Add
                </button>
                </form>
            </body>
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
