/// <binding />
var gulp = require("gulp");
var gmsbuild = require("gulp-msbuild");
var foreach = require("gulp-foreach");
var rename = require("gulp-rename");
var watch = require("gulp-watch");

var config = require("./gulp-config.js")();

gulp.task("Publish", function() {
    var publishProjects = function(location) {
        gulp.src(location + "/**/*.csproj")
            .pipe(foreach(function (stream) {
                return stream.pipe(gmsbuild({
                        targets: ["Clean", "Build"], 
                        configuration: "Debug",
                        logCommand: false,
                        verbosity: "normal",
                        properties: { DeployOnBuild: "true", DeployDefaultTarget: "WebPublish", WebPublishMethod: "FileSystem", DeleteExistingFiles: "false", publishUrl: config.websiteRoot }
                    }));
            }));
    };

    console.log("Publishing solution");
    publishProjects("./src/Framework");
    publishProjects("./src/Domain");
    publishProjects("./src/Project");
});

gulp.task("Full-Build", ["Copy-Sitecore-Lib"], function() {
    console.log("Starting Full Build !!");
    gulp.src(config.solutionName + ".sln")
        .pipe(gmsbuild({
            targets: ["Clean", "Build"],
            configuration: "Debug",
            logCommand: false,
            verbosity: "normal"
        }));
    console.log("Done building");
});

gulp.task("Build", function() {
    console.log("Building solution");
    gulp.src(config.solutionName + ".sln")
        .pipe(gmsbuild({
            targets: ["Clean", "Build"],
            configuration: "Debug",
            logCommand: false,
            verbosity: "normal"
        }));
});

gulp.task("Copy-Sitecore-Lib", function() {
    console.log("Copying Sitecore Libraries");
    gulp.src(config.sitecoreLibraries + "/**/*")
        .pipe(gulp.dest("./lib/Sitecore"));
    console.log("Finished copying sitecore libraries", "color:red");
});

gulp.task("Auto-Publish-Design", function() {
    var root = "./src/project/design";
    gulp.watch(root + "/**/*.css", function(event) {
        if (event.type === "changed") {
            console.log("publish this file " + event.path);
            gulp.src(event.path, { base: root }).pipe(gulp.dest(config.websiteRoot));
        }
        console.log("published " + event.path);
    });
});