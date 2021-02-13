import plotly.graph_objects as go
import dash
import dash_core_components as dcc
import dash_html_components as html
from dash.dependencies import Input, Output
import tweepy
from textblob import TextBlob

# 4 cadenas para la autenticación
# Tokens de Twitter

APIkey = "tPhuYUlVME2IjA1rYsh26yXpa"
APIkeysecret = "dS7zZIp1Jgq9dB3inxerM5GcDB85tC0CoyyOBch0aDCJPGm4PT"
Accesstoken = "1146457499954044928-uVK4oBmxpb4SqAXRvtd8TwmJoE8SiR"
Accesstokensecret = "rn6LaX48qT3Gk1q47hSSTgGOqw9EahZitxX9DOgNkc2VH"

auth = tweepy.OAuthHandler(APIkey, APIkeysecret)
auth.set_access_token(Accesstoken, Accesstokensecret)

api = tweepy.API(auth, wait_on_rate_limit=True,
                 wait_on_rate_limit_notify=True)

polaBiden = []
subjBiden = []
tweetsBiden = []

polaTrump = []
subjTrump = []
tweetsTrump = []

def ExtraccionData(candidato):
    cont = 1
    for tweet in tweepy.Cursor(api.search, q=candidato, until="2021-02-08", len="en", tweet_mode="extended").items(100):

        blob = TextBlob(tweet._json["full_text"])

        polarity = blob.sentiment.polarity
        subjectivity = blob.sentiment.subjectivity

        if candidato == "JoeBiden":
            polaBiden.append(polarity)
            subjBiden.append(subjectivity)
            tweetsBiden.append(cont)
        if candidato == "realDonaldTrump":
            polaTrump.append(polarity)
            subjTrump.append(subjectivity)
            tweetsTrump.append(cont)

        cont = cont + 1

ExtraccionData("realDonaldTrump")
ExtraccionData("JoeBiden")
print("")
chart1 = go.Figure()

external_stylesheets = ['https://codepen.io/chriddyp/pen/bWLwgP.css']

app = dash.Dash(__name__, external_stylesheets=external_stylesheets)

graph1 = dcc.Graph(
        id='graph1',
        figure=chart1,
        #className="eight columns"
    )

multi_select_line_chart = dcc.Dropdown(
        id="multi_select_line_chart",
        options=[{"value":label, "label":label} for label in ["Donald Trump","Joe Biden","Polaridad","Subjetividad"]],
        value=["Tweet"],
        multi=True,
        clearable = False
    )

header = html.H2(children="PRUEBA DASHBOARD NODEL - Dúber Medina")

row1 = html.Div(children=[multi_select_line_chart, graph1], className="eight columns")

scatter_div = html.Div(children=[html.Div(className="row") ], className="six columns")

layout = html.Div(children=[header, row1], style={"text-align": "center", "justifyContent":"center"})

app.layout = layout

@app.callback(Output('graph1', 'figure'), [Input('multi_select_line_chart', 'value')])
def update_line(price_options):
    chart1 = go.Figure()

    for price_op in price_options:
        if price_op == "Tweet":
            chart1.add_trace(go.Scatter(x=tweetsBiden, y=polaBiden,
                                    mode="lines", name="Polaridad Biden"))
            chart1.add_trace(go.Scatter(x=tweetsBiden, y=subjBiden,
                                        mode="lines", name="Subjetividad Biden"))
            chart1.add_trace(go.Scatter(x=tweetsTrump, y=polaTrump,
                                        mode="lines", name="Polaridad Trump"))
            chart1.add_trace(go.Scatter(x=tweetsTrump, y=subjTrump,
                                        mode="lines", name="Subjetividad Trump"))
        if price_op == "Donald Trump":
            chart1.add_trace(go.Scatter(x=tweetsTrump, y=polaTrump,
                                            mode="lines", name="Polaridad Trump"))
            chart1.add_trace(go.Scatter(x=tweetsTrump, y=subjTrump,
                                            mode="lines", name="Subjetividad Trump"))
        if price_op == "Joe Biden":
            chart1.add_trace(go.Scatter(x=tweetsBiden, y=polaBiden,
                                            mode="lines", name="Polaridad Biden"))
            chart1.add_trace(go.Scatter(x=tweetsBiden, y=subjBiden,
                                            mode="lines", name="Subjetividad Biden"))

        if price_op == "Polaridad":
            chart1.add_trace(go.Scatter(x=tweetsBiden, y=polaBiden,
                                        mode="lines", name="Polaridad Biden"))
            chart1.add_trace(go.Scatter(x=tweetsTrump, y=polaTrump,
                                        mode="lines", name="Polaridad Trump"))
        if price_op == "Subjetividad":
            chart1.add_trace(go.Scatter(x=tweetsBiden, y=subjBiden,
                                        mode="lines", name="Subjetividad Biden"))
            chart1.add_trace(go.Scatter(x=tweetsTrump, y=subjTrump,
                                        mode="lines", name="Subjetividad Trump"))

    chart1.update_layout(
                         xaxis_title="Tweets",
                         yaxis_title="Sentimientos",
                         title="Inauguration Day [Jan-2021]",
                         height=500,)
    return chart1

if __name__ == "__main__":
    app.run_server(debug=True)