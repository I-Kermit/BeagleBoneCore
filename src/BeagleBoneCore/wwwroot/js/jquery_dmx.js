const DMX = "12, {SLIDER1}, {SLIDER2}, {SLIDER3}, {SLIDER4}, {SLIDER5}, {SLIDER6}, {SLIDER7}, {SLIDER8}, {SLIDER9}, {SLIDER10}, {SLIDER11}, {SLIDER12}";

var lastSentValues = DMX;

var dmxSendValues = "";

var slider1 = { label: "ch1", value: "ch1_val", attribute: "Red" };
var slider2 = { label: "ch2", value: "ch2_val", attribute: "Green" };
var slider3 = { label: "ch3", value: "ch3_val", attribute: "Blue" };
var slider4 = { label: "ch4", value: "ch4_val", attribute: "-" };
var slider5 = { label: "ch5", value: "ch5_val", attribute: "-" };
var slider6 = { label: "ch6", value: "ch6_val", attribute: "-" };
var slider7 = { label: "ch7", value: "ch7_val", attribute: "-" };
var slider8 = { label: "ch8", value: "ch8_val", attribute: "-" };
var slider9 = { label: "ch9", value: "ch9_val", attribute: "-" };
var slider10 = { label: "ch10", value: "ch10_val", attribute: "-" };
var slider11 = { label: "ch11", value: "ch11_val", attribute: "-" };
var slider12 = { label: "ch12", value: "ch12_val", attribute: "-" };

var sliders = {
    slider1,
    slider2,
    slider3,
    slider4,
    slider5,
    slider6,
    slider7,
    slider8,
    slider9,
    slider10,
    slider11,
    slider12
};

$(function () {
    // Get the channel value from the label
    var getChVal = function (id) {
        const htmlTag = document.getElementById(id);
        const value = htmlTag.innerText;
        return value;
    }

    // Get the channel value from the label
    var setChVal = function (id, value) {
        const htmlTag = document.getElementById(id);
        htmlTag.innerText = value;
    }

    function sendValues() {
        dmxSendValues = DMX.replace("{SLIDER1}", getChVal(sliders.slider1.value))
            .replace("{SLIDER2}", getChVal(sliders.slider2.value))
            .replace("{SLIDER3}", getChVal(sliders.slider3.value))
            .replace("{SLIDER4}", getChVal(sliders.slider4.value))
            .replace("{SLIDER5}", getChVal(sliders.slider5.value))
            .replace("{SLIDER6}", getChVal(sliders.slider6.value))
            .replace("{SLIDER7}", getChVal(sliders.slider7.value))
            .replace("{SLIDER8}", getChVal(sliders.slider8.value))
            .replace("{SLIDER9}", getChVal(sliders.slider9.value))
            .replace("{SLIDER10}", getChVal(sliders.slider10.value))
            .replace("{SLIDER11}", getChVal(sliders.slider11.value))
            .replace("{SLIDER12}", getChVal(sliders.slider12.value));

        if (dmxSendValues !== lastSentValues) {
            $.post("/Home/Program", { dmxValues: dmxSendValues });

            var htmlTag = document.getElementById("lastString");
            htmlTag.innerText = "Last: " + dmxSendValues;
            lastSentValues = dmxSendValues;
        }
    }

    // Send every 100ms to stop flooding values from slider.
    setInterval(function () { sendValues(); }, 100);

    $("#btnSend").click(function () {
        sendValues();
    });

    $("#btnReset").click(function () {

        $("#ch1").slider("value", 0);
        $("#ch2").slider("value", 0);
        $("#ch3").slider("value", 0);
        $("#ch4").slider("value", 0);
        $("#ch5").slider("value", 0);
        $("#ch6").slider("value", 0);
        $("#ch7").slider("value", 0);
        $("#ch8").slider("value", 0);
        $("#ch9").slider("value", 0);
        $("#ch10").slider("value", 0);
        $("#ch11").slider("value", 0);
        $("#ch12").slider("value", 0);

        setChVal(sliders.slider1.value, 0);
        setChVal(sliders.slider2.value, 0);
        setChVal(sliders.slider3.value, 0);
        setChVal(sliders.slider4.value, 0);
        setChVal(sliders.slider5.value, 0);
        setChVal(sliders.slider6.value, 0);
        setChVal(sliders.slider7.value, 0);
        setChVal(sliders.slider8.value, 0);
        setChVal(sliders.slider9.value, 0);
        setChVal(sliders.slider10.value, 0);
        setChVal(sliders.slider11.value, 0);
        setChVal(sliders.slider12.value, 0);

        sendValues();
    });


    // Slider objects
    // Red
    $("#" + sliders.slider1.label).slider({
        value: getChVal(sliders.slider1.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider1.value).text(ui.value);
        }
    });

    $("#" + sliders.slider2.label).slider({
        value: getChVal(sliders.slider2.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider2.value).text(ui.value);
        }
    });

    $("#" + sliders.slider3.label).slider({
        value: getChVal(sliders.slider3.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider3.value).text(ui.value);
        }
    });

    $("#" + sliders.slider4.label).slider({
        value: getChVal(sliders.slider4.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider4.value).text(ui.value);
        }
    });

    $("#" + sliders.slider5.label).slider({
        value: getChVal(sliders.slider5.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider5.value).text(ui.value);
        }
    });

    $("#" + sliders.slider6.label).slider({
        value: getChVal(sliders.slider6.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider6.value).text(ui.value);
        }
    });

    $("#" + sliders.slider7.label).slider({
        value: getChVal(sliders.slider7.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider7.value).text(ui.value);
        }
    });

    $("#" + sliders.slider8.label).slider({
        value: getChVal(sliders.slider8.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider8.value).text(ui.value);
        }
    });

    $("#" + sliders.slider9.label).slider({
        value: getChVal(sliders.slider9.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider9.value).text(ui.value);
        }
    });

    $("#" + sliders.slider10.label).slider({
        value: getChVal(sliders.slider10.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider10.value).text(ui.value);
        }
    });

    $("#" + sliders.slider11.label).slider({
        value: getChVal(sliders.slider11.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider11.value).text(ui.value);
        }
    });

    $("#" + sliders.slider12.label).slider({
        value: getChVal(sliders.slider12.value),
        orientation: "vertical",
        min: 0,
        max: 255,
        range: "min",
        slide: function (event, ui) {
            $("#" + sliders.slider12.value).text(ui.value);
        }
    });
});
