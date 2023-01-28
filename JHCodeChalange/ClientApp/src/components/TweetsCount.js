import React, { Component } from 'react';

export class TweetsCount extends Component {
    static displayName = TweetsCount.name;

    constructor(props) {
        super(props);
        this.state = { count: "0", loading: true };
    }

    componentDidMount() {
        this.populateData();
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <p>{this.state.count}</p>;

        return (
            <div>
                <h1 id="tableLabel">Tweets Count</h1>
                {contents}
                <button onClick={async (e) => { await this.populateData() }}>Refresh</button>
            </div>
        );
    }

    async populateData() {
        const response = await fetch('Tweets/TweetsCount');
        const data = await response.text();
        this.setState({ count: data, loading: false });
    }
}
